const express = require('express');
const fileUpload = require('express-fileupload');

const initFaceApi = require('./config/face');
const initDB = require('./config/db');

const faceRouter = require('./app/routes/face');

const app = express();

app.use(express.json());

app.use(
  fileUpload({
    useTempFiles: true,
  })
);

app.use(faceRouter);

const port = process.env.PORT || 3000;

app.listen(port, () => {
    console.log(`App is running on port = ${port}`);
});

initFaceApi();
initDB();