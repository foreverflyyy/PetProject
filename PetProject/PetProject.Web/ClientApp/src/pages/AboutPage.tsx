import { useInfo } from "../hooks/info";


export function AboutPage() {
   const { message } = useInfo();

   return (
      <p>{message}. </p>
   )
}