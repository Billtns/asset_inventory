import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

import { AssetsService } from '../../services/assets/assets.service';
import { CategoryService } from '../../services/cattegories/category.service';
import { StatusService } from '../../services/status/status.service';

import { Asset } from '../../models/asset.model';
import { Category } from '../../models/category.model';
import { Status } from '../../models/status.model';

import { MessageService } from 'primeng/api';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { InputTextModule } from 'primeng/inputtext';
import { SelectModule } from 'primeng/select';
import { ToastModule } from 'primeng/toast';

@Component({
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TableModule,
    DialogModule,
    ButtonModule,
    IconFieldModule,
    InputIconModule,
    InputTextModule,
    SelectModule,
    ToastModule
  ],
  templateUrl: './assets.component.html',
  providers: [MessageService]
})
export class AssetsComponent implements OnInit {

  assets: Asset[] = [];
  categories: Category[] = [];
  statuses: Status[] = [];
  viewData: any;

  form!: FormGroup;
  assetDialog = false;
  deleteDialog = false;
  viewDialog = false;
  isEdit = false;
  deleteAssetId: number | null = null;


  constructor(
    private fb: FormBuilder,
    private assetService: AssetsService,
    private categoryService: CategoryService,
    private statusService: StatusService,
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      assetId: [],
      assetName: ['', Validators.required],
      assetCode: [''],
      brand: [''],
      model: [''],
      serialNumber: [''],
      categoryId: [null, Validators.required],
      statusId: [null, Validators.required]
    });

    this.loadAssets();
    this.loadCategories();
    this.loadStatuses();
  }

  loadAssets() {
    this.assetService.getAssets().subscribe(res => this.assets = res);
  }

  loadCategories() {
    this.categoryService.getCategories().subscribe(res => this.categories = res);
  }

  loadStatuses() {
    this.statusService.getStatuses().subscribe(res => this.statuses = res);
  }

  hideDialog() {
    this.assetDialog = false;
  }

  Add() {
    this.isEdit = false;
    this.form.reset();
    this.assetDialog = true;
  }

  View(id: number) {
    this.assetService.getAsset(id).subscribe(res => {
      this.viewData =(res);
      this.viewDialog = true;
    });
  }


  Edit(id: number) {
    this.isEdit = true;
    this.assetService.getAsset(id).subscribe(res => {
      this.form.patchValue(res);
      this.assetDialog = true;
    });
  }

  saveAsset() {
    if (this.form.invalid) return;

    const action$ = this.isEdit
      ? this.assetService.updateAsset(this.form.value)
      : this.assetService.createAsset(this.form.value);

    action$.subscribe(res => {
      if (res.status) {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: res.message
        });
        this.loadAssets();
        this.assetDialog = false;
      }
    });
  }

  Delete(id: number) {
    this.deleteAssetId = id;
    this.deleteDialog = true;
  }

  confirmDelete() {
    if (!this.deleteAssetId) return;

    this.assetService.deleteAsset(this.deleteAssetId).subscribe(res => {
      if (res.status) {
        this.messageService.add({
          severity: 'success',
          summary: 'Deleted',
          detail: res.message
        });
        this.loadAssets();
      }
      this.deleteDialog = false;
      this.deleteAssetId = null;
    });
  }
}
