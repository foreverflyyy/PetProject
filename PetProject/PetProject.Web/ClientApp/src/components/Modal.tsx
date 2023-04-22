import React from 'react';
import '../styles/user.css'
import { IModalWindow } from '../models';

interface ModalProps {
   modalWindow: IModalWindow;
   children: React.ReactNode;
   onClose: () => void;
}

export function Modal({ modalWindow, children, onClose }: ModalProps) {

   return (
      <>
         <div className="modal-background" onClick={onClose}>

         </div>
         <div className="modal-window">
            <div className="modal-content">
               <h1>{modalWindow.title}</h1>
               {children}
            </div>
         </div>
      </>
   );
}