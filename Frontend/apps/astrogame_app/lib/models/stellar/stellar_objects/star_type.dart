import 'package:json_annotation/json_annotation.dart';

enum StarType {
  @JsonValue(0)
  brownDwarf,

  @JsonValue(1)
  yellowDwarf,

  @JsonValue(2)
  whiteStar,

  @JsonValue(3)
  redGiant,

  @JsonValue(4)
  blueGiant,
}
