import React, { useState } from 'react';
import { HiArrowCircleLeft, HiArrowCircleRight } from "react-icons/hi";
import { RiCoupon2Line, RiCoupon3Line, RiDashboard2Line } from "react-icons/ri";
import { TbCategory, TbShoppingCart, TbShoppingCartCog } from "react-icons/tb";
import { FaUser, FaUserCog } from "react-icons/fa";
import { Layout, Menu, Button, theme } from 'antd';
import { useNavigate, Outlet } from 'react-router-dom';
const { Header, Sider, Content } = Layout;
const MainLayout = () => {
  const [collapsed, setCollapsed] = useState(false);
  const {
    token: { colorBgContainer },
  } = theme.useToken();
  const navigate = useNavigate();
  return (
    <Layout>
      <Sider trigger={null} collapsible collapsed={collapsed}>
        <div className="demo-logo-vertical"><h1 className='fs-5 text-center py-3 mb-0 t-lg'>PHB</h1></div>
        <Menu
          theme="dark"
          mode="inline"
          defaultSelectedKeys={['']}
          onClick={({ key }) => {
            if (key === 'signout') {

            }
            else {
              navigate(key);
            }
          }}
          items={[
            {
              key: '',
              icon: <RiDashboard2Line className='fs-5' />,
              label: 'Dashboard',
            },
            {
              key: 'product',
              icon: <TbShoppingCart className='fs-5' />,
              label: 'Product',
              children: [
                {
                  key: 'add-product',
                  icon: <TbShoppingCartCog className='fs-5' />,
                  label: 'Add Product',
                },
                {
                  key: 'product-list',
                  icon: <TbShoppingCartCog className='fs-5' />,
                  label: 'Product List',
                },
                {
                  key: 'category',
                  icon: <TbCategory className='fs-5' />,
                  label: 'Category',
                },
                {
                  key: 'category-list',
                  icon: <TbCategory className='fs-5' />,
                  label: 'Category List',
                },
              ],
            },
            {
              key: 'customer',
              icon: <FaUser className='fs-5' />,
              label: 'Customer',
              children: [
                {
                  key: 'add-customer',
                  icon: <FaUserCog className='fs-5' />,
                  label: 'Add Customer',
                },
                {
                  key: 'customer-list',
                  icon: <FaUserCog className='fs-5' />,
                  label: 'Customer List',
                },
              ]
            },
            {
              key: 'coupon',
              icon: <RiCoupon2Line className='fs-5' />,
              label: 'Coupon',
              children: [
                {
                  key: 'add-coupon',
                  icon: <RiCoupon3Line className='fs-5' />,
                  label: 'Add Coupon',
                },
                {
                  key: 'coupon-list',
                  icon: <RiCoupon3Line className='fs-5' />,
                  label: 'Coupon List',
                },
              ],
            },
          ]}
        />
      </Sider>
      <Layout>
        <Header
          className='d-flex justify-content-between pe-5'
          style={{
            padding: 0,
            background: colorBgContainer,
          }}
        >
          <Button
            type="text"
            icon={collapsed ? <HiArrowCircleRight /> : <HiArrowCircleLeft />}
            onClick={() => setCollapsed(!collapsed)}
            style={{
              fontSize: '30px',
              display: 'flex',
              justifyContent: 'center',
              alignItems: 'center',
              width: 64,
              height: 64,
            }}
          />
          <div className='d-flex gap-3 align-items-center'>
            <div><img className='img-acc' src='https://upload-os-bbs.hoyolab.com/upload/2022/01/01/46384184/f3cc0c07f6797640387f443b53c001ff_6540641865418857049.png' alt='' /></div>
            <div><h5 className='fs-5 text-center py-3 mb-0'>Name</h5></div>
          </div>
        </Header>
        <Content
          style={{
            margin: '24px 16px',
            padding: 24,
            minHeight: 280,
            background: colorBgContainer,
          }}
        >
          <Outlet />
        </Content>
      </Layout>
    </Layout>
  );
};
export default MainLayout;