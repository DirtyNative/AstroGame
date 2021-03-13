import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class StellarThing {
  @JsonKey()
  Guid id;

  @JsonKey()
  String name;
}
