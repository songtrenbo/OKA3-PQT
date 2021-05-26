'use strict'

const express = require('express');
const eventController = require('../controllers/eventController');
const router = express.Router();

const{themKH,themHang,layTaiKhoan,layMatKhau,layTKMK,xoaTK,suaTK,thongTinUser,dsUsers,xemPhieuQT,taoHD,taoCTHD,suaHH,taoPhieuQT,dsHH,suaPhieuQT,dsPhieuQT} = eventController;

// router.post('/logins',getUser);

router.post('/register',themKH);
router.post('/login',layTKMK);
router.get('/login/:TaiKhoan',layTaiKhoan);
router.get('/login/:MatKhau',layMatKhau);
router.get('/info/:MaUser',thongTinUser);
router.get('/list/:MaQuyen',dsUsers);
router.get('/view/:MaUser',xemPhieuQT);
router.delete('/delete/:MaUser',xoaTK);
router.put('/updateTK/:id', suaTK);
router.post('/createHang',themHang);
router.post('/createHoaDon',taoHD);
router.post('/createCTHoaDon',taoCTHD);
router.put('/updateHang', suaHH);
router.post('/createPhieuQT',taoPhieuQT);
router.get('/listHang',dsHH);
router.put('/updatePhieuQT', suaPhieuQT);
router.get('/listPhieuQT',dsPhieuQT);


module.exports ={
    router:router
}