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
  console.log('Example app listening at http://localhost:8000')
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
  
  res.write('{status:200, data:\n')
  for (let i=0; i<movies.length; i++){
    my= JSON. stringify(movies[i]);
    res.write(my+"\n");


  }
  res.write('}')
  res.end();


});


//By-Date
app.get('/movies/read/by-date', (req, res) =>{
    year=movies.sort(function(a, b) {
      var yearOfa = a.year, yearOfb = b.year;
      return yearOfa - yearOfb ;
  })

  
    res.write('{status:200, data:\n')
    for (let i=0; i<year.length; i++){
      my= JSON. stringify(year[i]);
      res.write(my+"\n");


    }
    res.write('}')
    res.end();


});

//By-Rating
app.get('/movies/read/by-rating', (req, res) =>{
  rating =movies.sort(function(a, b) {
    return b.rating - a.rating;
  
  })


  res.write('{status:200, data:\n')
  for (let i=0; i<year.length; i++){
    my= JSON. stringify(rating[i]);
    res.write(my+"\n");


  }
  res.write('}')
  res.end();


});


//By-Title
app.get('/movies/read/by-title', (req, res) =>{
  title =movies.sort(function(a, b) {
    var titleA = a.title.toLowerCase(), titleB = b.title.toLowerCase();
    if (titleA < titleB) return -1;
    if (titleA > titleB) return 1;
    return 0;
  });
  


  res.write('{status:200, data:\n')
  for (let i=0; i<year.length; i++){
    my= JSON. stringify(title[i]);
    res.write(my+"\n");


  }
  res.write('}')
  res.end();


});


app.get('/movies/read/id/:id?', (req, res) => {

    if(req.params.id< movies.length){

      res.send({status:200, data:movies[req.params.id]})
    }else{res.send({status:404, error:true, message:'the movie title does not exist'})}
  
  
  
  });




app.get('/movies/add/title=:title?&year=:year?&rating=:rating?', function (req, res) {
  let y=req.params.year.toString();
  if (req.params.title && !isNaN(req.params.year)&& y.length===4  ){
    if( req.params.rating){
      movies.push({title:req.params.title , year:req.params.year , rating:req.params.rating })
    }

     else {
      movies.push({title:req.params.title , year:req.params.year , rating:4})
     }
     
    }
    else {
    res.send({status:403, error:true, message:'you cannot create a movie without providing a title and a year'})
    }
    res.write('{status:200, data:\n')
    for (let i=0; i<movies.length; i++){
      my= JSON. stringify(movies[i]);
      res.write(my+"\n");
  
  
    }
    res.write('}')
    res.end();
  
  
  });
 
