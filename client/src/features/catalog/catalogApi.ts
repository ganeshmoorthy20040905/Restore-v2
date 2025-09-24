import { createApi} from "@reduxjs/toolkit/query/react";
import type { Product } from "../../app/models/product";
import { baseQueryWithErrorHandling } from "../../app/api/baseAPI";


export const catalogApi= createApi({
    reducerPath:'catalogApi',
    baseQuery :baseQueryWithErrorHandling,
    endpoints:(bulider)=>({
        fetchProducts:bulider.query<Product[],void>({
            query:() =>({url:'products'})
        }),
          fatchProductDetails :bulider.query<Product,number>({
            query:(productId) =>`products/ ${productId}`
        })
    })
});

export const {useFatchProductDetailsQuery,useFetchProductsQuery}=catalogApi;