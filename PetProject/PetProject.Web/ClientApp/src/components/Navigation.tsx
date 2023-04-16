import { Link } from 'react-router-dom'

export function Navigation() {
   return (

      <nav className="nav-navigation">
         <span className="">React 2023</span>

         <span>
            <Link to="/about">About page</Link>
            <Link to="/">Product page</Link>
         </span>
      </nav>
   )
}