#!/usr/bin/env sh

set -e

cd ./build/

git init
git add -A

timestamp="`date +'%Y-%m-%dT%T.%3N%z'`"
git commit -m "deploy @ $timestamp"

git push -f git@github.com:r08521610/icg2020.git master:gh-pages

cd -
