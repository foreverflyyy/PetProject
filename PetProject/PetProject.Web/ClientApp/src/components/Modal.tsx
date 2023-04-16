import React from 'react';
import '../styles/product.css'

interface ModalProps {
   children: React.ReactNode;
   onClose: () => void;
}

export function Modal({ children, onClose }: ModalProps) {

   return (
      <>
         <div className="modal-background" onClick={onClose}>

         </div>
         <div className="modal-window">
            <div className="modal-content">
               <h1>Create new User</h1>
               {children}
            </div>
         </div>
      </>
   );
}