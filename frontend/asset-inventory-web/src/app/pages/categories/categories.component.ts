import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CategoryService } from '../../services/cattegories/category.service';
import { Category } from '../../models/category.model';
import { MessageService } from 'primeng/api';

import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { InputTextModule } from 'primeng/inputtext';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';


@Component({
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TableModule,
    TagModule,
    InputTextModule,
    IconFieldModule,
    InputIconModule,
    ButtonModule,
    DialogModule,
    ToastModule
  ],
  templateUrl: './categories.component.html',
  providers: [MessageService]
})

export class CategoriesComponent implements OnInit {

  categories: Category[] = [];
  viewData: any;

  form!: FormGroup;
  categoryDialog = false;
  deleteDialog = false;
  viewDialog = false;
  isEdit = false;
  deleteCategoryId: number | null = null;

  constructor(private fb: FormBuilder,
    private categoryService: CategoryService,
    private messageService: MessageService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      categoryId: [],
      categoryName: ['', Validators.required]
    });

    this.loadCategories();
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe({
      next: (res) => this.categories = res,
      error: (err) => console.error(err)
    });
  }

  Add() {
    this.isEdit = false;
    this.form.reset();
    this.categoryDialog = true;
  }

  View(id: number) {
    this.categoryService.getCategory(id).subscribe(res => {
      this.viewData = (res);
      this.viewDialog = true;
    });
  }

  Edit(id: number) {
    this.isEdit = true;
    this.categoryService.getCategory(id).subscribe({
      next: (res) => {
        this.form.patchValue(res);
        this.categoryDialog = true;
      },
      error: (err) => console.error(err)
    });

  }

  hideDialog() {
    this.categoryDialog = false;
  }

  saveCategory() {
    if (this.form.invalid) return;

    if (this.form.invalid) return;

    const payload = { ...this.form.value };

    const action$ = this.isEdit ? this.categoryService.updateCategory(payload) : this.categoryService.createCategory(payload);


    action$.subscribe({
      next: (res) => {
        if (res.status) {
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: res.message
          });
          this.loadCategories();
          this.categoryDialog = false;
        }
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Operation failed'
        });
      }
    });
  }

  Delete(id: number) {
    this.deleteCategoryId = id;
    this.deleteDialog = true;
  }

  confirmDelete() {
    if (!this.deleteCategoryId) return;
    this.categoryService.deleteCategory(this.deleteCategoryId).subscribe(res => {
      if (res.status) {
        this.messageService.add({
          severity: 'success',
          summary: 'Deleted',
          detail: res.message
        });
        this.deleteDialog = false;
        this.loadCategories();
      }
      this.deleteCategoryId = null;
    });
  }
}
