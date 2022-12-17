const mongoose = require('mongoose');

const MONGODB_URI = `mongodb://127.0.0.1/gps-medical-assistance`;

module.exports = () => {
  const connect = () => {
    mongoose
      .connect(MONGODB_URI)
      .then(() => {
        console.log('DB connected and server us running.');
      })
      .catch((err) => {
        console.log(err);
      });
  };

  connect();
};
