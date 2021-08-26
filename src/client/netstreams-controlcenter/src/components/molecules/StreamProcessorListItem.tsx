import React, { FC } from "react";
import { Col, Row } from "react-bootstrap";
import greenCircle from "../../images/green_circle.png";
import redCircle from "../../images/red_circle.png";

interface StreamProcessorListItemProps {
  displayName: string;
  active: boolean;
}

export const StreamProcessorListItem: FC<StreamProcessorListItemProps> = ({
  displayName,
  active,
}: StreamProcessorListItemProps) => {
  const statusSource = active ? greenCircle : redCircle;

  return (
    <Row className="stream-processor-list-item">
      <Col>
        <img src={statusSource} alt="" className="processor-status" />
        {displayName}
      </Col>
    </Row>
  );
};
