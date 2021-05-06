'use strict'

const express = require('express');
const eventController = require('../controllers/eventController');
const router = express.Router();

const{getUser,themKH,themHang,layTaiKhoan,layMatKhau,layTKMK,xoaTK,suaTK,thongTinUser} = eventController;

router.post('/logins',getUser);

router.post('/register',themKH);
router.post('/hang',themHang);
router.post('/login',layTKMK);
router.get('/login/:TaiKhoan',layTaiKhoan);
router.get('/login/:MatKhau',layMatKhau);
router.delete('/xoatk/:MaUser',xoaTK);
router.put('/suatk/:id', suaTK);
router.get('/info/:MaUser',thongTinUser);
module.exports ={
    router:router
}