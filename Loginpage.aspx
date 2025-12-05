<%@ page title="" language="C#" masterpagefile="~/fixitmasterpage.master" autoeventwireup="true" codefile="Loginpage.aspx.cs" inherits="Loginpage" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <head>
        <title>Login Page</title>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.1/css/all.css" integrity="sha384-gfdkjb5BdAXd+lj+gudLWI+BXq4IuLW5IT+brZEZsLFm++aCMlF1V92rMkPaX4PP" crossorigin="anonymous">
        <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <body>
        <div class="container login-wrapper">
            <div class="container h-100">
                <div class="d-flex justify-content-center h-100">
                    <div class="user_card">
                        <div class="d-flex justify-content-center login_container">
                            <div class="brand_logo_container">
                                <img src="images/Logo[99].jpg" class="brand_logo" alt="Logo" />
                            </div>
                        </div>
                        <form action="Loginpage.aspx">
                            <div class="container mt-0 login_container">
                                <h3 class="container mt-5 align-items-center login_container">Member Login</h3>
                                <div class="container mt-auto align-items-center login_container">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-user"></i></span>
                                            <asp:textbox id="Txtboxempcode" cssclass="form-control input_user" textmode="SingleLine" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="container align-items-center login_container">
                                    <div class="input-group mb-2">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text"><i class="fas fa-key"></i></span>
                                            <asp:textbox id="Txtboxpass" cssclass="form-control input_pass" tooltip="Enter your password" textmode="Password" runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group login_container">
                                    <div class="custom-control custom-checkbox">
                                        <asp:checkbox id="customControlInline" cssclass="custom-control-input" runat="server"></asp:checkbox>
                                        <label class="custom-control-label" for="customControlInline">Remember me</label>
                                    </div>
                                </div>
                                <!-- Forgot Password Link -->
                                <div class="login_container text-right mb-2">
                                    <asp:hyperlink id="lnkForgotPassword" runat="server" navigateurl="ForgotPassword.aspx" cssclass="text-primary" font-size="Small">Forgot Password?</asp:hyperlink>
                                </div>
                                <div class="container mt-2 login_container">
                                    <asp:button id="Btnlogin" cssclass="btn login_btn" runat="server" onclick="Button1_Click" text="Login"></asp:button>
                                </div>
                                <div class="mt-4 ">
                                    <%--<div class="container  align-items-center login_container">
						Don't have an account? <a href="#" class="ml-2">Sign Up</a>
					</div>--%>
                                    <div class="container  align-items-center login_container">
                                        <%--		 <asp:HyperLink id="hyperlink1" NavigateUrl="loginpassword.aspx" Text="Change password?" runat="server"/>
                                        --%>
                                    </div>
                                </div>
                            </div>
                            <center>
                                <asp:label id="Lblmessage" runat="server"></asp:label>
                            </center>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <center>
            <br />
            <asp:label id="lblVersion" runat="server" text="v2.3.0.0" font-size="X-Small" forecolor="White"></asp:label>
        </center>
    </body>
</asp:Content>

