const express = require('express');
const controller = require('../controllers/face');

const router = express.Router();

router.post(`/post-face`, controller.postFace);

router.post(`/check-face`, controller.checkFace);

module.exports = router;
