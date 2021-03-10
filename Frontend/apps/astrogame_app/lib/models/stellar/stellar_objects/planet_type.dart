import 'package:json_annotation/json_annotation.dart';

enum PlanetType {
  @JsonValue(0)
  volcano,

  @JsonValue(1)
  desert,

  @JsonValue(2)
  continental,

  @JsonValue(3)
  ocean,

  @JsonValue(4)
  rock,

  @JsonValue(5)
  gas,

  @JsonValue(6)
  ice,

  @JsonValue(7)
  gaia,
}
