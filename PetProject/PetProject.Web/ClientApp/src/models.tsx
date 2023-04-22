export interface IUser {
   id?: number,
   name: string,
   age?: number
}

export interface IModalWindow {
   user: IUser,
   title: string,
   btnText: string,
   flag: boolean
}