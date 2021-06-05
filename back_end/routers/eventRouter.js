'use strict'

const express = require('express');
const eventController = require('../controllers/eventController');
const router = express.Router();

const{themKH,themHang,layTaiKhoan,layMatKhau,layTKMK,xoaTK,suaTK,thongTinUser,dsUsers,xemPhieuQT,taoHD,taoCTHD,suaHH,taoPhieuQT,dsHH,suaPhieuQT,dsPhieuQT,xemCTHD,dsHD} = eventController;

// router.post('/logins',getUser);

router.post('/register',themKH);
router.post('/login',layTKMK);
router.get('/login/:TaiKhoan',layTaiKhoan);
router.get('/login/:MatKhau',layMatKhau);
router.get('/infoUser/:MaUser',thongTinUser);
router.get('/listUser/:MaQuyen',dsUsers);
router.get('/viewPhieuQT/:MaUser',xemPhieuQT);
router.delete('/deleteTK/:MaUser',xoaTK);
router.put('/updateTK/:id', suaTK);
router.post('/createHang',themHang);
router.post('/createHoaDon',taoHD);
router.post('/createCTHoaDon',taoCTHD);
router.put('/updateHang', suaHH);
router.post('/createPhieuQT',taoPhieuQT);
router.get('/listHang',dsHH);
router.put('/updatePhieuQT', suaPhieuQT);
router.get('/listPhieuQT',dsPhieuQT);
router.get('/viewCTHD/:MaHD',xemCTHD);
router.get('/listHoaDon/:MaUser',dsHD);


module.exports ={
    router:router
}