;#DropDB CountableSystemEasyTest

#Application CountableSystem.Win
#Application CountableSystem.Web

*FillForm
 User Name = Admin
*Action Log In

#IfDef CountableSystem.Win

*Action About...
 
*Action OK

#EndIf

#IfDef CountableSystem.Web
*Action Navigation(My Details)
#EndIf
