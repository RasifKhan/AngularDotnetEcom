import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Product } from './shared/models/product';
import { Pagination } from './shared/models/pagination';
import { ShopService } from './core/services/shop.service';
import { ShopComponent } from "./features/shop/shop.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, ShopComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
//   //baseUrl= 'https://localhost:5001/api/'     //removesd after configuraing shop.service.ts
//   //private http=inject(HttpClient)            ////removesd after configuraing shop.service.ts

//  private shopService=inject (ShopService);

//   title = 'Skinet';
//   //products: any[] = [];
//   products: Product[] = [];

//   ngOnInit(): void {
//    // this.http.get<any>(this.baseUrl + 'products').subscribe
//    // this.http.get<Pagination<Product>>(this.baseUrl + 'products').subscribe({   //////removesd after configuraing shop.service.ts
//    this.shopService.getProducts().subscribe({ 
//       next: response =>this.products = response.data,
//       error: error =>console.log(error),
      
//       //complete: () => console.log('complete')
//     })
    
  
//   }

title = 'Skinet';


}
