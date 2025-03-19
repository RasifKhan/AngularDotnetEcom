
// export interface Product  {

// }
// we will use type instead of an interface 


//camelCasig
 export type Product  ={
      id : number;
      name :string;
      description : string;
      price : number; // we don't have decimal for typeScipt
      pictureUrl : string;
      type : string;
      brand : string;
      quantityInStock : number;
 }