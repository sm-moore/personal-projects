#! /bin/bash

clear

n1="Victoria: "
n2="Fred: "

s1="I am Victoria."

Victoria=`ls`

$Victoria

s2="and I am Fred."
echo "$n2$s2"
say -v Fred "$s2"

s1="We are here to tell you a story."
echo "$n1$s1"
say -v Victoria "$s1"

s2="It's a good one too so stick around."
echo "$n2$s2"
say -v Fred "$s2"

s1="Once upon"
echo "$n1$s1"
say -v Victoria "$s1"
