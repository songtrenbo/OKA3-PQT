"use strict";

const e = require("express");
const eventData = require("../data/events");

const getUser = async (req, res) => {
  try {
    const dataTen = req.body;
    const datamk = req.body;
    const data1 = req.body;
    const oneTen = await eventData.getTenUser(dataTen);
    const oneMk = await eventData.getMK(datamk);
    const oneUser = await eventData.loginUser(data1);

    if (oneTen != "") {
      if (oneMk != "") {
        if (oneUser != "") {
          res.status(200).send({
            message: "Successful login!",
          });
        } else {
          res.status(200).send({
            message: "Password incorrect!",
          });
        }
      } else {
        res.status(200).send({
          message: "Password incorrect!",
        });
      }
    } else {
      res.status(200).send({
        message: "User not found!",
      });
    }
  } catch (error) {
    res.status(400).end(error.message);
  }
};

const layTKMK = async (req, res) => {
  try {
    const tkmk = req.body;
    const TKMK = await eventData.layTKMK(tkmk);
    res.send(TKMK);
  } catch (error) {
    res.status(400).send(error.message);
  }
}

const layMatKhau = async (req, res) => {
  try {
    const matkhau = req.params.MatKhau;
    const matKhau = await eventData.layMK(matkhau);
    res.send(matKhau);
  } catch (error) {
    res.status(400).send(error.message);
  }
}

const layTaiKhoan = async (req, res) => {
  try {
    const taikhoan = req.params.TaiKhoan;
    const taiKhoan = await eventData.layTK(taikhoan);
    res.send(taiKhoan);
  } catch (error) {
    res.status(400).send(error.message);
  }
}

const themKH = async (req, res) => {
  try {
    const dataKH = req.body;
    const created = await eventData.themKH(dataKH);
    res.send(created);
  } catch (error) {
    res.status(400).send(error.message);
  }
}
const themHang = async (req, res) => {
  try {
    const dataHang = req.body;
    const created = await eventData.themHang(dataHang);
    res.send(created);
  } catch (error) {
    res.status(400).send(error.message);
  }
}

const xoaTK = async (req,res)=>{
  try {
      const mauser = req.params.MaUser;
      const xoatk = await eventData.xoaTK(mauser);
      res.send(xoatk);
  } catch (error) {        
      res.status(400).send(error.message);
  }
}
const suaTK = async (req,res)=>{
  try {
      const eventId=req.params.id;
      const data = req.body;
      const updated = await eventData.suaTK(eventId,data);
      res.send(updated);
  } catch (error) {
      res.status(400).send(error.message);
  }
}
const thongTinUser = async (req,res)=>{
  try {
      const eventId = req.params.MaUser;
      const oneEvent = await eventData.thongTinUser(eventId);
      res.send(oneEvent);
  } catch (error) {
      res.status(400).send(error.message);
  }
}


module.exports = {
  getUser,
  layTKMK,
  layMatKhau,
  layTaiKhoan,
  themKH,
  themHang,
  xoaTK,
  suaTK,
  thongTinUser
};