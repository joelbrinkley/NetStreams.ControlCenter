import React, { FC } from "react";
import { Container } from "react-bootstrap";
import { StreamProcessorListItem } from "./StreamProcessorListItem";
import { StreamProcessorDisplay } from "../../models";


interface StreamProcessorListProps {
  streamProcessors: Array<StreamProcessorDisplay>;
}

export const StreamProcessorList: FC<StreamProcessorListProps> = ({
  streamProcessors,
}: StreamProcessorListProps) => {
  return (
    <Container>
      {streamProcessors.map((sp, i) => {
        return <StreamProcessorListItem 
        displayName={sp.name} 
        active={sp.status}
        key={i} />;
      })}
    </Container>
  );
};
