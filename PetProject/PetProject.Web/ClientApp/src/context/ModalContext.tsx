import React, { createContext, useState } from 'react';
import { IModalWindow } from '../models';

interface IModalContext {
   modalWindow: IModalWindow,
   open: () => void,
   close: () => void
}

export const ModalContext = createContext<IModalContext>({
   modal: false,
   open: () => { },
   close: () => { }
})

export const ModalState = ({ children }: { children: React.ReactNode }) => {

   const [modalWindow, setModalWindow] = useState<IModalWindow>();

   const open = () => {
      modalWindow.flag = true;
      setModalWindow(modalWindow);
   }

   const close = () => {
      setModalWindow(false);
   }

   return (
      <ModalContext.Provider value={{ modalWindow, close, open }}>
         {children}
      </ModalContext.Provider>
   )
}
