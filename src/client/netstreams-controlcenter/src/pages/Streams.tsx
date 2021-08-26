import React, { FC } from "react";
import { Container } from "react-bootstrap";
import { StreamProcessorList } from "../components/molecules";
import { StreamProcessorDisplay } from "../models";

export const Streams: FC = () => {
  
  const streamProcessors: Array<StreamProcessorDisplay> = 
    [
      {name: "stream processor 1", status: true},
      {name: "stream processor 2", status: false}
    ];

  return (
    <Container>
        <StreamProcessorList streamProcessors={streamProcessors} />
    </Container>
  );
};
