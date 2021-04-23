import 'package:json_annotation/json_annotation.dart';

enum ResearchType {
  @JsonValue(0)
  physics,

  @JsonValue(1)
  engineering,

  @JsonValue(2)
  biology,

  @JsonValue(3)
  social,

  @JsonValue(4)
  astronomy,

  @JsonValue(5)
  industry,

  @JsonValue(6)
  military,

  @JsonValue(7)
  newWorlds,
}
