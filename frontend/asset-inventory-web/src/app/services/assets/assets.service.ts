import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Asset } from '../../models/asset.model';
import { ResponseModel } from '../../models/response.model';


@Injectable({
    providedIn: 'root'
})
export class AssetsService {

    private apiUrl = `${environment.apiUrl}/Assets`;

    constructor(private http: HttpClient) { }

    // GET: list
    getAssets(): Observable<Asset[]> {
        return this.http.get<Asset[]>(`${this.apiUrl}/Get`);
    }

    // GET: by id
    getAsset(id: number): Observable<Asset> {
        return this.http.get<Asset>(`${this.apiUrl}/GetById/${id}`);
    }

    // POST: create
    createAsset(data: any): Observable<ResponseModel> {
        return this.http.post<ResponseModel>(`${this.apiUrl}/Create`, data);
    }

    // PUT: update
    updateAsset(data: any): Observable<ResponseModel> {
        return this.http.put<ResponseModel>(`${this.apiUrl}/Update`, data);
    }

    // DELETE
    deleteAsset(id: number): Observable<ResponseModel> {
        return this.http.delete<ResponseModel>(`${this.apiUrl}/Delete/${id}`);
    }
}
