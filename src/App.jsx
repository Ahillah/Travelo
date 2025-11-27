import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

 import SignUp from "./Components/pages/Authtemplate/SignUp";
 import SignUPT from "./Components/pages/Authtemplate/SignUPT";
 import SignUpH from "./Components/pages/Authtemplate/SignUpH";
const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<SignUp />} />
        <Route path="/SignUPT" element={<SignUPT />} />
        <Route path="/SignUpH" element={<SignUpH />} />
      </Routes>
    </Router>
  );
};

export default App;
