const express = require('express')
const app = express()
const port = 8000
let date_ob=new Date();

// current hours
let hours = date_ob.getHours();

// current minutes
let minutes = date_ob.getMinutes();

app.get('/', (req, res) => {
  res.send('ok')
})

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:8000`)
})

app.get('/test', function (req, res) {
  res.send('{status:200, message:"ok"}')
})

app.get('/time',(req, res) =>{
   res.send( '{status:200, message:' + hours +":"+minutes+ '}')
})


// a middleware sub-stack that handles GET requests to the /user/:id path
app.get('/hello/:id?', function (req, res) {
  // if the user ID is 0, skip to the next router
  if (req.params.id){
  res.send("{status:200, message:Hello,"+req.params.id+"}")}
  else {
  // render a regular page
  res.send("{status:200, message:Hello }")
}})

// a middleware sub-stack that handles GET requests to the /user/:id path
app.get('/search=:s?', function (req, res) {
  // if the user ID is 0, skip to the next router
  if (req.params.s){
  res.send('{status:200, message:"ok",data:'+req.params.s+'}')}
  else {
  // render a regular page
  res.send('{status:500, error:true, message:"you have to provide a search"}')
}})