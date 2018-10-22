<%@ Page Language="C#" AutoEventWireup="true" CodeFile="single.aspx.cs" Inherits="single" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Edman</title>

    <!-- Bootstrap  CSS -->
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <!--  custom CSS here -->
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
   
     <!-- Nav Section -->
    <nav class=" navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand logo-nav" href="#>
                    <img src="img/logo.png" alt="">
                </a>
            </div>

            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav navbar-right margin-top">
                    <li><a href="#">Men</a>
                    </li>
                    <li><a href="#">Women</a>
                    </li>
                    <li><a href="#">Kids</a>
                    </li>
                    <li><a href="#">Offers</a>
                    </li>
                  
                    <li><a href="#">Cart</a>
                    </li>
                </ul>
            </div>
            
        </div>
      
    </nav>
     <!--End Nav Section -->
     <!-- Carousel Section -->
    
     <!--End Carousel Section -->
    <!--Products Section -->
    <div class="container">
         
        <div class="row">
            <div class="col-md-8 col-sm-8 mr-top-50">
                <a href="#" >
                <img  src="img/portfolio1.jpg" class="img-responsive mr-botm">
                    </a>
                 <h3>QUICK OVERVIEW OF ITEM</h3>
                <p>
Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    </p>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                </p>
                 <p>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                </p>
            </div>
            <div class="col-md-4 col-sm-4 mr-top-50">
                <h3>Project Details</h3>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                </p>
                <h3>Links Below</h3>
                <ul>
                    <li>Lorem Ipsum</li>
                    <li>Lorem Ipsum</li>
                    <li>Lorem Ipsum</li>
                    <li>Lorem Ipsum</li>
                </ul>
                <p>
                    <a href="#" class="btn btn-primary btn-lg" role="button">BUY NOW @ $ 500</a> 
                </p>
            </div>
          
            </div>
           <!-- /.row -->
        <div class="row">
            <h3 style="margin-left:30px;">Related Items Here</h3>
            <hr />
            <div class="col-md-3 col-sm-3 text-center">
                <a href="#" >
                    
                <img  src="img/imgS1.jpg" class="img-responsive">
                   
                    </a>
                <h4>Item Name Here</h4>
            </div>
            <div class="col-md-3 col-sm-3 text-center">
                <a href="#" >
                <img  src="img/imgS2.jpg" class="img-responsive">
                    </a>
                 <h4>Item Name Here</h4>
            </div>
           <div class="col-md-3 col-sm-3 text-center">
                <a href="#" >
                <img  src="img/imgS1.jpg" class="img-responsive">
                    </a>
                <h4>Item Name Here</h4>
            </div>
           <div class="col-md-3 col-sm-3 text-center">
                <a href="#" >
                <img  src="img/imgS2.jpg" class="img-responsive">
                    </a>
                <h4>Item Name Here</h4>
            </div>
            </div>
        <!-- /.row -->

    </div>
   <!--End Products Section -->

    <!-- JavaScript -->
    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/bootstrap.js"></script>
    </form>
</body>
</html>
