----
--The Basic Level
---

--Create a basic Table--
basic = {};

--What to do on entering the basic level--
function onEnter()
  print("Opening your own profile...")
end;

--Add some text--
basic.description = "The first profile";
basic.name = "Your Own Profile";

--Add a function pointer--
basic.OnEnter = onEnter;