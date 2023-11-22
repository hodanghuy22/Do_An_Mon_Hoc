import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import MainLayout from "./Components/Mainlayout";
import Home from "./pages/Home";
import Login from "./pages/Login";
import Resetpassword from "./pages/Resetpassword";
import Forgotpassword from "./pages/Forgotpassword";
import Detail from "./pages/PhoneDetail";
import Cart from "./pages/Cart";
import DienThoai from "./pages/DienThoai";
import DonHang from "./pages/DonHang";
import Thongtindiachi from "./pages/Thongtindiachi";
import AccountLayout from "./Components/AccountLayout";
import DanhSachYeuThich from "./pages/DanhSachYeuThich";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/reset-password" element={<Resetpassword />} />
        <Route path="/forgot-password" element={<Forgotpassword />} />
        <Route path="/" element={<MainLayout />}>
          <Route index element={<Home />} />
          <Route path="/dtdd/1" element={<Detail />} />
          <Route path="/cart" element={<Cart />} />
          <Route path="/dien-thoai" element={<DienThoai />} />
          <Route path="/lich-su-mua-hang" element={<AccountLayout />}>
            <Route index element={<DonHang />} />
            <Route path="thong-tin-tai-khoan" element={<Thongtindiachi />} />
            <Route path="san-pham-yeu-thich" element={<DanhSachYeuThich />} />
          </Route>
        </Route>
      </Routes>
    </Router>
  );
}

export default App;