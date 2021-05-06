"use strict";

const utils = require("../utils");
const config = require("../../config");
const sql = require("mssql");

const loginUser = async (eventData) => {
  try {
    let pool = await sql.connect(config.sql);
    const sqlQueries = await utils.loadSqlQueries("events");
    const oneUser = await pool
      .request()
      .input("TenUser", sql.NVarChar(50), eventData.TenUser)
      .input("MatKhau", sql.VarChar(25), eventData.MatKhau)
      .query(sqlQueries.getTenMK);
    return oneUser.recordset;
  } catch (error) {
    return error.message;
  }
};

const thongTinUser = async (eventId) => {
  try {
    let pool = await sql.connect(config.sql);
    const sqlQueries = await utils.loadSqlQueries("events");
    const oneEvent = await pool
      .request()
      .input("MaUser", sql.VarChar(9), eventId)
      .query(sqlQueries.thongTinUser);
    return oneEvent.recordset;
  } catch (error) {
    return error.message;
  }
};

const layTKMK = async (eventData) => {
    try {
      let pool = await sql.connect(config.sql);
      const sqlQueries = await utils.loadSqlQueries("events");
      const oneUser = await pool
        .request()
        .input("TaiKhoan", sql.NVarChar(100), eventData.TaiKhoan)
        .input("MatKhau", sql.VarChar(25), eventData.MatKhau)
        .query(sqlQueries.layTKMK);
      return oneUser.recordset;
    } catch (error) {
      return error.message;
    }
  };

const layTK = async (taikhoan) => {
  try {
    let pool = await sql.connect(config.sql);
    const sqlQueries = await utils.loadSqlQueries("events");
    const laytaikhoan = await pool
      .request()
      .input("TaiKhoan", sql.VarChar(100), taikhoan)
      .query(sqlQueries.layTaiKhoan);
    return laytaikhoan.recordset;
  } catch (error) {
    return error.message;
  }
};
const layMK = async (matkhau) => {
  try {
    let pool = await sql.connect(config.sql);
    const sqlQueries = await utils.loadSqlQueries("events");
    const laymatkhau = await pool
      .request()
      .input("MatKhau", sql.VarChar(25), matkhau)
      .query(sqlQueries.layMatKhau);
    return laymatkhau.recordset;
  } catch (error) {
    return error.message;
  }
};

const themKH = async (eventData) => {
  try {
    let pool = await sql.connect(config.sql);
    const sqlQueries = await utils.loadSqlQueries("events");
    const taoKH = await pool
      .request()
      .input("TenUser", sql.VarChar(50), eventData.TenUser)
      .input("Email", sql.VarChar(sql.MAX), eventData.Email)
      .input("TaiKhoan", sql.VarChar(50), eventData.TaiKhoan)
      .input("MatKhau", sql.VarChar(32), eventData.MatKhau)
      .query(sqlQueries.themKH);
    return taoKH.recordset;
  } catch (error) {
    return error.message;
  }
};

const themHang = async (eventData) => {
  try {
    let pool = await sql.connect(config.sql);
    const sqlQueries = await utils.loadSqlQueries("events");
    const themhang = await pool
      .request()
      .input("TenHH", sql.NVarChar(50), eventData.TenHH)
      .input("Gia", sql.Float, eventData.Gia)
      .input("TrangThai", sql.Bit, eventData.TrangThai)
      .input("MaLoai", sql.VarChar(25), eventData.MaLoai)
      .input("MaDT", sql.Int, eventData.MaDT)
      .input("MaSize", sql.Int, eventData.MaSize)
      .input("MoTa", sql.NVarChar(sql.MAX), eventData.MoTa)
      .input("Hinh", sql.VarChar(sql.MAX), eventData.Hinh)
      .query(sqlQueries.themHang);
    return themhang.recordset;
  } catch (error) {
    return error.message;
  }
};

const xoaTK = async (eventId)=>{
    try {
        let pool = await sql.connect(config.sql);
        const sqlQueries = await utils.loadSqlQueries('events');
        const xoa = await pool.request()
                        .input('MaUser',sql.VarChar(9),eventId)
                        .query(sqlQueries.xoaTaiKhoan);
        return xoa.recordset;
    } catch (error) {
        return error.message;            
    }
}
const suaTK = async (eventId, eventData)=>{
    try {
        let pool=await sql.connect(config.sql);
        const sqlQueries = await utils.loadSqlQueries('events');
        const update = await pool.request()
                        .input('MaUser',sql.VarChar(9),eventId)
                        .input('TenUser',sql.NVarChar(100),eventData.TenUser)
                        .input('Email',sql.NVarChar(200),eventData.Email)
                        .input('TaiKhoan',sql.VarChar(100),eventData.TaiKhoan)
                        .input('MatKhau',sql.VarChar(25),eventData.MatKhau)
                        .input('MaQuyen',sql.VarChar(25),eventData.MaQuyen)
                        .query(sqlQueries.suaTaiKhoan);
        return update.recordset;
    } catch (error) {
        return error.message;        
    }
}
module.exports = {
  loginUser,
  thongTinUser,
  layTKMK,
  layTK,
  layMK,
  themKH,
  themHang,
  xoaTK,
  suaTK
};
