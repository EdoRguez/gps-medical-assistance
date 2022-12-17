const faceapi = require("face-api.js");
const canvas = require("canvas");

const model = require("../models/face");

async function uploadLabeledImages(image, label) {
  try {
    const img = await canvas.loadImage(image);
    // Read each face and save the face descriptions in the descriptions array
    const detections = await faceapi
      .detectSingleFace(img)
      .withFaceLandmarks()
      .withFaceDescriptor();

    // Create a new face document with the given label and save it in DB
    const createFace = new model({
      label: label,
      description: detections.descriptor,
    });
    await createFace.save();
    return true;
  } catch (error) {
    console.log(error);
    return error;
  }
}

async function getDescriptorsFromDB(image) {
  // Get all the face data from mongodb and loop through each of them to read the data
  let faces = await model.find();
  for (i = 0; i < faces.length; i++) {
    // Change the face data descriptors from Objects to Float32Array type
    faces[i].description = new Float32Array(
      Object.values(faces[i].description)
    );

    // Turn the DB face docs to
    faces[i] = new faceapi.LabeledFaceDescriptors(faces[i].label, [
      faces[i].description,
    ]);
  }

  // Load face matcher to find the matching face
  const faceMatcher = new faceapi.FaceMatcher(faces, 0.6);

  // Read the image using canvas or other method
  const img = await canvas.loadImage(image);
  let temp = faceapi.createCanvasFromMedia(img);
  // Process the image for the model
  const displaySize = { width: img.width, height: img.height };
  faceapi.matchDimensions(temp, displaySize);

  // Find matching faces
  const detections = await faceapi
    .detectAllFaces(img)
    .withFaceLandmarks()
    .withFaceDescriptors();
  const resizedDetections = faceapi.resizeResults(detections, displaySize);
  const result = resizedDetections.map((d) =>
    faceMatcher.findBestMatch(d.descriptor)
  )[0];

  return result;
}

exports.postFace = async (req, res) => {
  const File1 = req.files.File1.tempFilePath;
  const label = req.body.label;
  let result = await uploadLabeledImages(File1, label);

  if (result) {
    res.send({ isSuccess: true });
  } else {
    res.send({ isSuccess: false });
  }
};

exports.checkFace = async (req, res) => {
  const File1 = req.files.File1.tempFilePath;
  let result = await getDescriptorsFromDB(File1);
  res.send(result);
};
