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

---------


const express = require('express')
const app = express()
const port = 8000
let date_ob=new Date();

const movies = [
    { title: 'Jaws', year: 1975, rating: 8 },
    { title: 'Avatar', year: 2009, rating: 7.8 },
    { title: 'Brazil', year: 1985, rating: 8 },
    { title: 'الإرهاب والكباب‎', year: 1992, rating: 6.2 }
]

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



app.get('/hello/:id?', function (req, res) {
  
  if (req.params.id){
  res.send("{status:200, message:Hello,"+req.params.id+"}")}
  else {
  
  res.send("{status:200, message:Hello }")
}})

app.get('/search=:s?', function (req, res) {

  if (req.params.s){
  res.send('{status:200, message:"ok",data:'+req.params.s+'}')}
  else {
  
  res.send('{status:500, error:true, message:"you have to provide a search"}')
}})

app.get('/movies/read', (req, res) => {
    for (var i=0; i<movies.length; i++){
        var m = movies[i];
        res.send('data:'+m);
    }
  })

----------


app.get('/movies/read', (req, res) => {
    res.write('{status:200, data:')
    for (let i=0; i<movies.length; i++){

         res.write(movies[i])

    }
    res.write('}')
    res.end()
  })


const express = require('express')
const app = express()
const port = 8000
let date_ob=new Date();

const movies = [
    { title: 'Jaws', year: 1975, rating: 8 },
    { title: 'Avatar', year: 2009, rating: 7.8 },
    { title: 'Brazil', year: 1985, rating: 8 },
    { title: 'الإرهاب والكباب‎', year: 1992, rating: 6.2 }
]

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



app.get('/hello/:id?', function (req, res) {
  
  if (req.params.id){
  res.send("{status:200, message:Hello,"+req.params.id+"}")}
  else {
  
  res.send("{status:200, message:Hello }")
}})

app.get('/search=:s?', function (req, res) {

  if (req.params.s){
  res.send('{status:200, message:"ok",data:'+req.params.s+'}')}
  else {
  
  res.send('{status:500, error:true, message:"you have to provide a search"}')
}})

app.get('/movies/read', (req, res) => {
    res.send('{status:200, data:')
    for (let i=0; i<movies.length; i++){
        let m = movies[i].title;
    }
    for(let j = 0; j < m.length; j++){ 
        res.send(m[j]);
    }

    res.send('}')

  })
---------------------------


app.get('/movies/read/id/:id?', (req, res) => {

    if(req.params.id< movies.length){

      res.send({status:200, data:movies[req.params.id]})
    }else{res.send({status:404, error:true, message:'the movie title does not exist'})}
  
  
  
  });


  -----------

  http://localhost:8000/movies/add/title=khalilk&year=1999&rating=