import React from "react";
import { Button, Container, Typography } from "@material-ui/core";
/**
 * This View is used to display a message when the backend is not reachable.
 */
export default function MissingBackend(props) {
  return (
    <Container>
      <Typography>
        The application daemon is not running. Please launch it and reopen this
        application.
      </Typography>
      <Typography>Do you need to download the daemon?</Typography>
      <Button
        variant="outlined"
        onClick={() =>
          window.shell.openExternal(
            "https://github.com/GhostyJade/ControllizerDeck"
          )
        }
      >
        Get it here.
      </Button>
    </Container>
  );
}
