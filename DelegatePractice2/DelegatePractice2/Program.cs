using DelegatePractice2.Domain;
using DelegatePractice2.Publisher;
using DelegatePractice2.Subscribers;

var userService = new UserService();

var email = new EmailNotifier();
var audit = new AuditLogger();
var security = new SecurityMonitor();

userService.UserLoggedIn += email.OnUserLogged;
userService.UserLoggedIn += audit.OnUserLogged;
userService.UserLoggedIn += security.OnUserLogged;

userService.UserLogged(new User(1, "nagendra", "Analyst"));
