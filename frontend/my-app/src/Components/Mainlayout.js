import { FiSearch, FiSmartphone } from "react-icons/fi";
import { FaComputer } from "react-icons/fa6";
import { BiHeadphone } from "react-icons/bi";
import { FaRegUser } from "react-icons/fa";
import { BsCartCheck, BsPhone, BsLaptop, BsTabletLandscape, BsSmartwatch } from "react-icons/bs";
import React, { useEffect, useState } from 'react'
import { Navbar, Nav, Form, FormControl, Button, Modal } from 'react-bootstrap';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link, Outlet } from "react-router-dom";
const Mainlayout = () => {
    const [show, setShow] = useState(false);
    const [isLogin, setIsLogin] = useState(true);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleSwitch = () => {
        setIsLogin(!isLogin);
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        // Xử lý đăng nhập hoặc đăng ký tại đây
        // ...
        handleClose();
    };


    const [showButton, setShowButton] = useState(false);

    useEffect(() => {
        const handleScroll = () => {
            const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
            setShowButton(scrollTop > 500); // Hiển thị nút khi người dùng cuộn xuống 500px
        };

        window.addEventListener('scroll', handleScroll);

        return () => {
            window.removeEventListener('scroll', handleScroll);
        };
    }, []);

    const scrollToTop = () => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth',
        });
    };

    return (

        <>
            <div className='m-auto' style={{ width: 1200 }}>
                <header className="mb-3 ">
                    <Navbar bg="body-tertiary" className="p-0 pt-2 pb-2 mb-4 ">
                        <Container fluid>

                            <Link to="/">
                                <img src='/logo_no_bachground.png' width={40} alt="Logo" />
                                PHBshop
                            </Link>
                            <Navbar.Toggle aria-controls="navbarSupportedContent" />
                            <div className="d-flex ml-auto">

                                <Navbar.Collapse id="navbarSupportedContent">
                                    <Form className="d-flex ml-2 mr-2" role="search">
                                        <FormControl type="search" placeholder="Bạn tìm gì" aria-label="Bạn tìm gì" />
                                        <Button variant="outline-secondary" onClick={handleShow}><FiSearch /></Button>
                                    </Form>
                                    <Nav className="me-auto mb-2 mb-lg-0">
                                        <Link to='/lich-su-mua-hang' active className="btn btn-warning ml-2 mr-2">Tài khoản và đơn hàng</Link>
                                        <Link to="/cart" className="btn btn-warning ml-2 mr-2"><BsCartCheck /> Giỏ hàng</Link>
                                        <Button className="btn btn-warning ml-2 mr-2" onClick={handleShow}><FaRegUser /> Đăng Nhập</Button>
                                        {/* <NavDropdown title="Dropdown" id="basic-nav-dropdown" className="ml-2 mr-2">
                                    <NavDropdown.Item href="#">Action</NavDropdown.Item>
                                    <NavDropdown.Item href="#">Another action</NavDropdown.Item>
                                    <NavDropdown.Divider />
                                    <NavDropdown.Item href="#">Something else here</NavDropdown.Item>
                                </NavDropdown> */}
                                    </Nav>
                                </Navbar.Collapse>
                            </div>

                        </Container>
                    </Navbar>
                    <Container className="p-0 m-0" >
                        <Row>
                            <Col>
                                <Link to="/dien-thoai" role="button"><BsPhone className="icon-link" />Điện thoại</Link>
                            </Col>
                            <Col><span role="button"><BsLaptop className="icon-link" />Laptop</span></Col>
                            <Col><span role="button"><BsTabletLandscape className="icon-link" />Tablet</span></Col>
                            <Col><span role="button"><BiHeadphone className="icon-link" />Phụ kiện</span></Col>
                            <Col><span role="button"><BsSmartwatch className="icon-link" />Smartwatch</span></Col>
                            <Col><span role="button"><FiSmartphone className="icon-link" />Máy cũ giá rẻ</span></Col>
                            <Col><span role="button"><FaComputer className="icon-link" />PC, Máy in</span></Col>
                        </Row>
                    </Container>
                </header>

                <main className="mt-3">
                    <Outlet />
                </main>

                <Container className='mt-5'>
                    <Row>
                        Footer
                    </Row>
                    <Row>
                        <Col xl>
                            <ul>
                                <li>Item 1</li>
                                <li>Item 2</li>
                                <li>Item 3</li>
                            </ul>
                        </Col>
                        <Col xl>
                            <ul>
                                <li>Item 1</li>
                                <li>Item 2</li>
                                <li>Item 3</li>
                            </ul>

                        </Col>
                        <Col xl>
                            <ul>
                                <li>Item 1</li>
                                <li>Item 2</li>
                                <li>Item 3</li>
                            </ul>
                        </Col>
                    </Row>
                    <Row xl={12} md={12}>
                        <h3>Hồ Đăng Huy - Nguyễn Minh Phát - Phạm Quảng Bình</h3>
                    </Row>
                </Container>
            </div>
            <Modal show={show} onHide={handleClose} style={{ marginTop: '10%' }}>
                <Modal.Header >
                    <Modal.Title>{isLogin ? 'Đăng Nhập' : 'Đăng Ký'}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={handleSubmit}>
                        {/* Các trường đăng nhập / đăng ký ở đây */}
                        <Form.Group controlId="formBasicEmail">
                            <Form.Label>Email</Form.Label>
                            <Form.Control type="email" placeholder="Nhập Email" />
                        </Form.Group>

                        <Form.Group controlId="formBasicPassword" className="mt-2">
                            <Form.Label>Password</Form.Label>
                            <Form.Control type="password" placeholder="Nhập Mật Khẩu" />
                        </Form.Group>
                        <Button variant="primary" type="submit" className="mt-3">
                            {isLogin ? 'Đăng Nhập' : 'Đăng Ký'}
                        </Button>
                    </Form>



                </Modal.Body>
                <Modal.Footer>
                    <p >
                        <Link to='forgot-password' className="mr-3 text-primary btn">Quên mật khẩu</Link>
                        {isLogin
                            ? "Bạn chưa có tài khoản? "
                            : "Bạn đã có tài khoản? "}
                        <span className="auth-switch text-primary btn " onClick={handleSwitch}>
                            {isLogin ? 'Đăng Ký ngay!' : 'Đăng Nhập ngay!'}
                        </span>
                    </p>
                </Modal.Footer>
            </Modal>
            {showButton && (
                <Button variant="primary" className="fixed-bottom float-right" onClick={scrollToTop} style={{ width: '80px', marginBottom: '40px', position: 'fixed', right: '10px' }}>
                    Top
                </Button>
            )}

        </>
    )
}

export default Mainlayout
