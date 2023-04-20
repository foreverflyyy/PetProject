import { Navigation } from "./components/Navigation";
import { Route, Routes } from 'react-router-dom';
import { UserPage } from "./pages/UserPage";
import { AboutPage } from "./pages/AboutPage";

function App() {

   return (
      <>
         <Navigation />
         <Routes>
            <Route path="/" element={<UserPage />} />
            <Route path="/about" element={<AboutPage />} />
         </Routes>
      </>

   );
}

export default App;
