import { useEffect, useState } from 'react';
//import axios from 'axios';
import '../styles/user.css'

export function useInfo() {

   const [message, setMessage] = useState('');

   async function GetResponse() {
      try {
         //const response = await axios.get<string>('https://localhost:7215/user');
         //console.log(response.data);
         setMessage("Lorem ipsum dolor sit, amet consectetur adipisicing elit. Harum dolor laborum nobis" +
            "pariatur consequatur illo. Vitae incidunt nostrum repudiandae quia!");
      } catch (e: unknown) {
         setMessage('not working request');
      }
   }

   useEffect(() => {
      GetResponse();
   }, []);

   return { message }
}