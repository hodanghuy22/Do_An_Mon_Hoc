import React from 'react'
import { Button, Col, Container, FormControl, Image, InputGroup, Row } from 'react-bootstrap'
import { IoMdArrowBack } from "react-icons/io";
import { Link } from 'react-router-dom';
const Thanhtoan = () => {
    return (
        <div>
            <Container className='w-50 m-auto '>
                <Row >
                    <Link to="/dien-thoại" className='text-center w-100 bg-info'><IoMdArrowBack className='float-left mt-2 h3' /> <p className='h4 mt-2'>Thông tin</p></Link>
                </Row>
                <Row className='mt-2 border-top text-center '>
                    <Col className='mr-2  border-bottom border-danger text-danger font-weight-bold'>
                        1.THÔNG TIN
                    </Col>
                    <Col className='ml-2 border-bottom border-gray  font-weight-bold'>
                        2.THANH TOÁN
                    </Col>
                </Row>
                <div>
                    <Row className=' pb-2 mb-4   mt-4 bg-light shadow p-4 mb-5 bg-white rounded'>
                        <Col xl={2} md={2} sm={2} className='p-2'>
                            <Image src='https://bit.ly/3ul4poY' width={'75px'} />
                        </Col>
                        <Col xl={7} md={7} sm={7}>
                            <h5>Đồng hồ thông minh BeFit Watch Ultra S 52.1mm</h5>
                            <p className='text-danger'>Giá: 1.490.000đ</p>
                        </Col>
                        <Col xl={3} md={3} sm={3} className='text-right'>
                            <p>Số lượng: <span>2</span></p>
                        </Col>
                    </Row>
                    <Row>
                        <div className='  bg-light shadow p-4 mb-5 bg-white rounded w-100 d-content-a'>
                            <h4>THÔNG TIN KHÁCH HÀNG</h4>
                            <form>
                                <div class="form-group w-50">
                                    <label for="hoTen">Họ tên người nhận</label>
                                    <input type="text" class="form-control" id="hoTen" placeholder="Nhập họ tên" />
                                </div>
                                <div class="form-group w-50">
                                    <label for="soDienThoai">Số điện thoại người nhận</label>
                                    <input type="tel" class="form-control" id="soDienThoai" placeholder="Nhập số điện thoại" />
                                </div>
                                <div class="form-group">
                                    <label for="email">Email người nhận</label>
                                    <input type="email" class="form-control" id="email" placeholder="Nhập email" />
                                </div>
                                <div class="form-group">
                                    <label for="cuaHang">Chọn cửa hàng đến nhận hàng</label>
                                    <select class="form-control" id="cuaHang">
                                        <option value="">-- Chọn cửa hàng --</option>
                                        <option value="cuaHang1">Cửa hàng 1</option>
                                        <option value="cuaHang2">Cửa hàng 2</option>
                                        <option value="cuaHang3">Cửa hàng 3</option>
                                    </select>
                                </div>
                            </form>
                        </div>

                    </Row>
                    <Row>
                        <div className='  bg-light shadow p-4 mb-5 bg-white rounded w-100 d-content-a'>
                            <h4>THÔNG TIN NHẬN HÀNG</h4>
                            <div class="form-group">
                                <label for="thanhPho">Hồ Chí Minh</label>
                                <input type="text" class="form-control" id="thanhPho" placeholder="Nhập tỉnh/thành phố" />
                            </div>
                            <div class="form-group">
                                <label for="quanHuyen">Chọn quận/huyện</label>
                                <select class="form-control" id="quanHuyen">
                                    <option value="">-- Chọn quận/huyện --</option>
                                    <option value="quan1">Quận 1</option>
                                    <option value="quan2">Quận 2</option>
                                    <option value="quan3">Quận 3</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label for="phuongXa">Chọn phường/xã</label>
                                <select class="form-control" id="phuongXa">
                                    <option value="">-- Chọn phường/xã --</option>
                                    <option value="phuong1">Phường 1</option>
                                    <option value="phuong2">Phường 2</option>
                                    <option value="phuong3">Phường 3</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label for="soNhaDuong">Số nhà, tên đường</label>
                                <input type="text" class="form-control" id="soNhaDuong" placeholder="Nhập số nhà, tên đường" />
                            </div>
                            <div class="form-group">
                                <label for="ghiChu">Ghi chú khác (nếu có)</label>
                                <textarea class="form-control" id="ghiChu" rows="3" placeholder="Nhập ghi chú"></textarea>
                            </div>
                        </div>
                    </Row>
                    <Row>
                        <Button variant='text-danger'>Thanh toán</Button>
                    </Row>
                </div>
                <div>
                    <div>
                        <input type='text' placeholder='Nhập mã giảm giá (chỉ ap dụng 1 lần)' className='float-lèt' />
                        <p><span className='float-left btn btn-danger'>Áp dụng</span><input type='text' placeholder='Nhập mã giảm giá (chỉ ap dụng 1 lần)' className='float-lèt' /></p>
                        <p><span className='float-right'></span></p>
                        <p>Số lượng sản phẩm <span className='float-right'>02</span></p>
                        <p>Tiền hàng (tạm tính) <span className='float-right'>3.380.000đ</span></p>
                        <p>Phí vận chuyển<span className='float-right'>02</span></p>
                        <p>Tổng tiền đã bao gồm VAT <span className='float-right'>3.380.000đ</span></p>
                    </div>
                    <div>
                        <h4>THÔNG TIN THANH TOÁN</h4>
                        <h4>Chọn phương thức thanh toán</h4>
                    </div>
                    <div>
                        <p>Khách hàng<span className='float-right'>Pham Bình</span></p>
                        <p>Số diện thoại <span className='float-right'>0329155867</span></p>
                        <p>Emnail <span className='float-right'>02</span></p>
                        <p>Tiền hàng (tạm tính) <span className='float-right'>3.380.000đ</span></p>
                    </div>
                    <Row>
                        <Button variant='text-danger bg-danger w-100 text-light'>Thanh toán</Button>
                    </Row>
                </div>
            </Container>
        </div>
    )
}

export default Thanhtoan
