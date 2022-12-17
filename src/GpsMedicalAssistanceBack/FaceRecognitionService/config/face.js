const faceapi = require("face-api.js");
const { Canvas, Image } = require("canvas");

faceapi.env.monkeyPatch({ Canvas, Image });

module.exports = () => {
  const loadModels = async () => {
    await faceapi.nets.faceRecognitionNet.loadFromDisk(
      __dirname + "/../models"
    );
    await faceapi.nets.faceLandmark68Net.loadFromDisk(__dirname + "/../models");
    await faceapi.nets.ssdMobilenetv1.loadFromDisk(__dirname + "/../models");
  };

  loadModels();
};
