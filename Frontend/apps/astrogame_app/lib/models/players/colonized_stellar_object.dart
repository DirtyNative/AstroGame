import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'colonized_stellar_object.g.dart';

@GuidConverter()
@JsonSerializable()
class ColonizedStellarObject {
  Guid id;
  Guid playerId;
  DateTime colonizedOn;
  Guid stellarObjectId;

  ColonizedStellarObject();

  factory ColonizedStellarObject.fromJson(Map<String, dynamic> json) =>
      _$ColonizedStellarObjectFromJson(json);
  Map<String, dynamic> toJson() => _$ColonizedStellarObjectToJson(this);
}
