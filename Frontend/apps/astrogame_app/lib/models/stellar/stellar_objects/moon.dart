import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/coordinates.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:json_annotation/json_annotation.dart';

part 'moon.g.dart';

@GuidConverter()
@JsonSerializable()
class Moon extends StellarObject {
  @JsonKey()
  late double scale;

  @JsonKey()
  late double axialTilt;

  @JsonKey()
  List<StellarObjectResource> resources = [];

  @JsonKey()
  late int order;

  Moon();

  factory Moon.fromJson(Map<String, dynamic> json) => _$MoonFromJson(json);
  Map<String, dynamic> toJson() => _$MoonToJson(this);
}
