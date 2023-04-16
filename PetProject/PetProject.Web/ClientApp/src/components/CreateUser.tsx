import React, { useState } from 'react';
import '../styles/product.css'
import { IProduct } from '../models';
import axios from 'axios';
import { ErrorMessage } from './ErrorMessage';

const productData: IProduct = {
   title: '',
   price: 1000,
   description: 'This is a product',
   image: 'https://i.pravatar.cc',
   category: 'electronic',
   rating: {
      rate: 42,
      count: 10
   }
}

interface CreateUseProps {
   onCreate: (product: IProduct) => void
}

export function CreateUser({ onCreate }: CreateUseProps) {

   const [value, setValue] = useState('');
   const [error, setError] = useState('');

   const submitHandler = async (event: React.FormEvent) => {
      event.preventDefault();
      setError('');

      if (value.trim().length === 0) {
         setError('Please enter a value');
         return;
      }

      productData.title = value;
      const response = await axios.post('https://fakestoreapi.com/products', productData);

      onCreate(response.data);
   }

   const changeHandler = async (event: React.ChangeEvent<HTMLInputElement>) => {
      setValue(event.target.value);
   }

   return (
      <form onSubmit={submitHandler}>
         <input
            type="text"
            className="form-create-user"
            placeholder="Enter your user name"
            value={value}
            onChange={changeHandler}
         />

         <ErrorMessage message={error} />
         <button type="submit" className="btn-create-user">Create</button>
      </form>
   )
}