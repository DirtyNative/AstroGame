import 'package:json_annotation/json_annotation.dart';

enum MaterialType {
  @JsonValue(0)
  building,

  @JsonValue(1)
  consumables,

  @JsonValue(2)
  components,

  @JsonValue(3)
  alloys,

  @JsonValue(4)
  fuels,
}
