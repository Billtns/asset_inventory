export interface Asset {
  assetId: number;
  assetName: string;
  assetCode?: string;
  brand?: string;
  model?: string;
  serialNumber?: string;

  categoryId: number;
  categoryName: string;

  statusId: number;
  statusName: string;
}
