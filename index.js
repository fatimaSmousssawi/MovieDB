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
