# Study repo for git hooks

## Notes

According to [this SO post](https://stackoverflow.com/a/54281447/2193151), it is possible to specify a custom folder for the hooks with the following command:

``` cmd
git config --local core.hooksPath .githooks/
```

In the standard version of the pre-commit hook, only staged files are evaluated.

## Command line

To prevent the pre-commit hook being triggered, pass the `--no-verify` option to the command line.
