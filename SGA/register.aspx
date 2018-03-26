<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.Master" CodeBehind="register.aspx.cs" Inherits="SGA.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



   <div id="SocialButtons" style="text-align:center;">
   <br />
       <h2>Login with social media</h2>
       <p style="width:222px;padding-bottom:36px;   display:inline-block;
    margin:auto;">
        <asp:ImageButton ID="btnLoginWithFb" ImageUrl="~/Images/fb_login_image.png" runat="server" style="width:100%;border:0px;" OnClick="btnLoginWithFb_Click" /> 

            <asp:ImageButton ID="btnLoginWithLinkedIn" ImageUrl="~/Images/button-linkedin.png" runat="server" style="width:100%;border:0px;height:49px;" OnClick="btnLoginWithLinkedIn_Click1" />
        </p>
       
   </div>


      <div id="RegestrationForm" class="backColor" style="margin-top:10px;" >
                
                      <div style="width:50%;margin-left:30%;">
                          <br />
                          <b>Or Register Below</b>

                          <br /><br />

                        
                        <input type="text" id="FName" placeholder="First name" />

                         <label for="lname"></label>
                          <input type="text" id="lname"  placeholder="Last name"  />
                       

                       
                           <input type="text" id="eAddress"  placeholder="Email address" />
                      


                           <input type="text" id="confirmEmail"   placeholder="Confirm email address"/>
                             <input type="password" id="password"  placeholder="password" />
                          <input type="text" id="OrganisationName"  placeholder="Organisation name"/>
                           <input type="text" id="jobTitle" placeholder="Job Title" />

                       
                         <asp:DropDownList id="ddlJobRole" AutoPostBack="false"
                                runat="server">
                              <asp:ListItem Selected="True" Value="0"> Job role best described as ...</asp:ListItem>
                              <asp:ListItem Value="8"> CPO </asp:ListItem>
                              <asp:ListItem Value="4"> Procurement Director </asp:ListItem>
                              <asp:ListItem Value="6"> Procurement Leader/ Influencer </asp:ListItem>
                              <asp:ListItem Value="5"> Category Manager </asp:ListItem>
                              <asp:ListItem Value="3"> Strategic Sourcing </asp:ListItem>
                              <asp:ListItem Value="9"> VM/ SRM </asp:ListItem>
                             <asp:ListItem Value="1"> Analyst </asp:ListItem>
                             <asp:ListItem Value="2"> Procurement Support </asp:ListItem>
                             <asp:ListItem Value="7"> Supply Chain  </asp:ListItem>
                              <asp:ListItem Value="10"> Other  </asp:ListItem>
                           </asp:DropDownList>
                     
  
                             <input type="submit"  id="btnSend" value="" class="btn-go3"  />
                          <br />  <br />

                          </div>
               
                </div>    

    
    <script type="text/javascript">
           var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
           var alertHtml = '';
           var title = "Alert";
    $(document).ready(function () {
        $('#btnSend').colorbox({
            href: "Popup.aspx",
            width: "392px",
            height: "200px",
            onComplete: function () {
                $("#title").text(title);
                $('#alertMessage').text(alertHtml);
            }
        });

        $('#btnSend').click(function () {
            //$('#colorbox').css({ "display": "block" });
            var error = 0;
            var emptyFields = new Array();
            var name = $('#FName').val();
            if (name == '' || name == 'First name ...') {
                error = 1;
                emptyFields.push('First name');
            }
            var surname = $('#lname').val();
            if (surname == '' || surname == 'Last name ...') {
                error = 1;
                emptyFields.push('Last name');
            }
            var email = $('#eAddress').val();
            if (email == '' || email == 'Email ...') {
                error = 1;
                emptyFields.push('Email Address');
            }
            var jobRole = $("#<%=ddlJobRole.ClientID %>").val();
            if (jobRole == 0) {
                error = 1;
                emptyFields.push('Job role');
            }

            var cEmail = $('#confirmEmail').val();
            if (cEmail == '' || cEmail == 'Confirm email ...') {
                error = 1;
                emptyFields.push('Confirm email');
            }
            var password = $('#password').val();
            if (password == '' || password == 'Password ...') {
                error = 1;
                emptyFields.push('Password');
            }
            var orgName = $('#OrganisationName').val();
            if (orgName == '' || orgName == 'Organisation Name ...') {
                error = 1;
                emptyFields.push('Organisation Name');
            }

            var _jobTitle = $('#jobTitle').val();
            if (_jobTitle == '' || _jobTitle == 'Job Title ...') {
                error = 1;
                emptyFields.push('Job Title');
            }

            if (error) {
                $('#colorbox').css({ "display": "block" });
                alertHtml = 'Please enter ' + emptyFields.join(', ');
            }
            else if (email != '' && !filter.test(email)) {
                $('#colorbox').css({ "display": "block" });
                alertHtml = 'Please enter valid email id';
            }
            else if (email != cEmail) {
                $('#colorbox').css({ "display": "block" });
                alertHtml = 'The email addresses you entered are not the same. Please ensure they match!';
            }

            else {
                var json =
                        $.ajax({
                            type: "POST",
                            async: false,
                            url: "about_us.aspx/RegisterUser",
                            data: JSON.stringify({ 'fname': name, 'lname': surname, 'company': orgName, 'email': email, 'jobId': $("#<%=ddlJobRole.ClientID %>").val(), 'plainpassword': password }),
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.d == 's') {
                                    title = "Success";
                                    $('#colorbox').css({ "display": "block" });
                                    alertHtml = 'Thank you for registering. Your registration has been approved and a confirmation email sent to your inbox.';
                                    $('#FName').val('');
                                    $('#lname').val('');
                                    $('#eAddress').val('');
                                    $('#confirmEmail').val('');
                                    $('#password').val('');
                                    $('#OrganisationName').val('');
                                    $('#jobTitle').val('');
                                    ("#<%=ddlJobRole.ClientID %>").val("")
                                } else if (data.d == 'e') {
                                    $('#colorbox').css({ "display": "block" });
                                    alertHtml = 'Some error occured in the process, Please try again.';
                                } else if (data.d == 'u') {
                                    $('#colorbox').css({ "display": "block" });
                                    alertHtml = 'User name already exists.';
                                } else if (data.d == 'd') {
                                    $('#colorbox').css({ "display": "block" });
                                    alertHtml = 'Email address already exists.';
                                }
                            }
                        });
            }
        });

    });



    </script>


    <style type="text/css">


        .btn-go3 {line-height:28px; padding:0; outline:none; border:none; background:url(../images/btn-go3.png) left top no-repeat; width:47px; height:28px; cursor:pointer}

        input[type=text],input[type=password], select {
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
}

input[type=submit] {
    width: 100%;

    color: white;
    padding: 14px 20px;
    margin: 8px 449px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

input[type=submit]:hover {
   
}


        #SocialButtons {
        
         background-color:#EBEBE9;
        
        }

        #box1{
        
        width:50%;

         float:left;

        }

         #box2{
        
         width:50%;
  
         float:left;


          
        }


        #btn one {
        
            float: left;
    border-right: 1px solid #e8e8e8;
    width: 50%;
    min-height: 132px;
    margin-right: 30px;
        }
              

              #btn two {
        
            float: left;
    border-right: 1px solid #e8e8e8;
    width: 50%;
    min-height: 132px;
    margin-right: 30px;
        }

              .backColor{
                    background-color: #EBEBE9;
              }


              .Btn.Btn--facebook-rev {
    color: #3e86b4;
    background: #fff;
    border: 1px solid #3e86b4;
    -webkit-transition: .2s ease color,.2s ease background;
    transition: .2s ease color,.2s ease background;
}


              a.Btn {
    color: #fff;
}

              u-db {
    display: block;
}


              .Btn--l, .Pricing--grey .Pricing-head .Pricing--highlight .Btn {
    padding: .8em .9em .72em;
    font-size: 22px;
    font-weight: 400;
}


</style>

 </asp:Content>