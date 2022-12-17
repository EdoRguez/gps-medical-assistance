const mongoose = require("mongoose");

const faceSchema = new mongoose.Schema({
  label: {
    type: String,
    required: true,
    unique: true,
  },
  description: {
    type: Object,
    required: true,
  },
});

module.exports = mongoose.model("face", faceSchema);
