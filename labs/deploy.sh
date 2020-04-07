#!/usr/bin/env sh

set -e

cd ./build/

git init
git add -A
git commit -m '`deploy @ ${$(date +"%Y-%m-%dT%T.%3N%z")}`'

git push -f git@github.com:r08521610/icg2020_labs.git master:gh-pages

cd -
