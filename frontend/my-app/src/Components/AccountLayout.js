import React from 'react'
import { Button, Col, Container, Row } from 'react-bootstrap'
import { RiProfileFill } from "react-icons/ri"
import { FaClipboardList } from "react-icons/fa"
import { Link, Outlet } from 'react-router-dom'
import { FaHeart } from "react-icons/fa";
const AccountLayout = () => {
    return (
        <div>
            <Container>
                <Row>
                    <Col xl={3} className='mr-2'>
                        <h6>Anh <strong>Phạm Quảng Bình</strong></h6>
                        <div className='text-left'>
                            <Link to="/lich-su-mua-hang" variant='light' className='w-100 text-left btn mb-2'>
                                <FaClipboardList className='mr-2 h4 text-success' />
                                Đơn hàng đã mua
                            </Link>
                            <Link to="/lich-su-mua-hang/thong-tin-tai-khoan" variant='light' className='w-100 text-left btn mb-2'>
                                <RiProfileFill className='mr-2 h4 text-info' />Thông tin và số địa chỉ
                            </Link>

                            <Link to="/lich-su-mua-hang/san-pham-yeu-thich" variant='light' className='w-100 text-left btn mb-2'>
                                <FaHeart className='mr-2 h4 text-danger' />Sản phẩm yêu thích
                            </Link>
                        </div>
                        <Button variant='light' className='w-100  border border-danger'>
                            Đăng xuất
                        </Button>
                    </Col>
                    <Col xl={8}>
                     <Outlet/>
                    </Col>
                </Row>
            </Container>

        </div>
    )
}

export default AccountLayout
